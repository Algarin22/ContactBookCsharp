namespace ContactBook;

public class ContactMerger
{
    private class DuplicateSet
    {
        private readonly int[] parents;
        private readonly int[] rank;

        public DuplicateSet(int size)
        {
            parents = new int[size];
            rank    = new int[size];

            for (int i = 0; i < size; i++)
                parents[i] = i;
        }

        public int Find(int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]); // path compression
            return parents[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) return;

            // union by rank
            if (rank[rootX] < rank[rootY])      parents[rootX] = rootY;
            else if (rank[rootX] > rank[rootY]) parents[rootY] = rootX;
            else { parents[rootY] = rootX; rank[rootX]++; }
        }

        public bool Connected(int x, int y) => Find(x) == Find(y);
    }

    // ── Public API ───────────────────────────────────────────────────────────

    /// <summary>
    /// Recibe la lista completa de contactos, detecta duplicados por
    /// (fname+lname) Y (teléfono o email), fusiona cada grupo conservando
    /// el contacto más completo y devuelve la lista limpia.
    /// </summary>
    public List<Contact> Merge(List<Contact> contacts)
    {
        int n = contacts.Count;
        if (n <= 1) return new List<Contact>(contacts);

        var ds = new DuplicateSet(n);

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (AreDuplicates(contacts[i], contacts[j]))
                    ds.Union(i, j);
            }
        }

        // Agrupar índices por raíz
        var groups = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            int root = ds.Find(i);
            if (!groups.ContainsKey(root))
                groups[root] = new List<int>();
            groups[root].Add(i);
        }

        // Por cada grupo, conservar el contacto más completo
        var result = new List<Contact>();
        foreach (var group in groups.Values)
        {
            Contact best = contacts[group[0]];
            for (int k = 1; k < group.Count; k++)
            {
                Contact candidate = contacts[group[k]];
                if (CountFilledFields(candidate) > CountFilledFields(best))
                    best = candidate;
            }
            result.Add(best);
        }

        return result;
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static bool AreDuplicates(Contact a, Contact b)
    {
        bool sameName = string.Equals(a.GetFName(), b.GetFName(), StringComparison.OrdinalIgnoreCase)
                    && string.Equals(a.GetLName(), b.GetLName(), StringComparison.OrdinalIgnoreCase);

        if (!sameName) return false;

        bool aHasPhone = !string.IsNullOrWhiteSpace(a.GetPhone());
        bool bHasPhone = !string.IsNullOrWhiteSpace(b.GetPhone());
        bool aHasEmail = !string.IsNullOrWhiteSpace(a.GetEmail());
        bool bHasEmail = !string.IsNullOrWhiteSpace(b.GetEmail());

        // Al menos uno tiene teléfono y coinciden
        bool samePhone = aHasPhone && bHasPhone
                    && string.Equals(a.GetPhone(), b.GetPhone(), StringComparison.OrdinalIgnoreCase);

        // Al menos uno tiene email y coinciden
        bool sameEmail = aHasEmail && bHasEmail
                    && string.Equals(a.GetEmail(), b.GetEmail(), StringComparison.OrdinalIgnoreCase);

        // Ninguno tiene nada → solo nombre basta
        bool bothEmpty = !aHasPhone && !bHasPhone && !aHasEmail && !bHasEmail;

        // Uno tiene teléfono y el otro no tiene nada con qué contradecirlo
        bool phoneWithNoConflict = (aHasPhone || bHasPhone)
                                && (!aHasPhone || !bHasPhone || samePhone)
                                && (!aHasEmail || !bHasEmail || sameEmail)
                                && (samePhone || (!aHasPhone && bHasPhone) || (aHasPhone && !bHasPhone));

        return samePhone || sameEmail || bothEmpty || phoneWithNoConflict;
    }    
    private static int CountFilledFields(Contact c)
    {
        int count = 0;
        if (!string.IsNullOrWhiteSpace(c.GetFName())) count++;
        if (!string.IsNullOrWhiteSpace(c.GetLName())) count++;
        if (!string.IsNullOrWhiteSpace(c.GetPhone())) count++;
        if (!string.IsNullOrWhiteSpace(c.GetEmail())) count++;
        return count;
    }
}