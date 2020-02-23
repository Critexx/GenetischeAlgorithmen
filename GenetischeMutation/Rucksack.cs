namespace GenetischeMutation
{
    public class Rucksack
    {
        private readonly bool[] _genom;

        public Rucksack(bool[] Genom)
        {
            _genom = Genom;
        }

        public int Gesamtmasse => GetGesamtmasse();
        public int Gesamtwert => GetGesamtwert();
        public int Fitness => GetFitness();

        public bool[] GetGenomErsterAbschnitt()
        {
            return new[] { _genom[0], _genom[1], _genom[2], _genom[3], _genom[4] };
        }

        public bool[] GetGenomZweiterAbschnitt()
        {
            return new[] { _genom[5], _genom[6], _genom[7], _genom[8], _genom[9] };
        }
        private int GetGesamtmasse()
        {
            int gesamtmasse = 0;
            for(int i = 0; i < Vektor.List.Length; i++)
            {
                if(_genom[i])
                {
                    gesamtmasse += Vektor.List[i].Masse;
                }
            }
            return gesamtmasse;
        }

        private int GetGesamtwert()
        {
            int gesamtwert = 0;
            for (int i = 0; i < Vektor.List.Length; i++)
            {
                if (_genom[i])
                {
                    gesamtwert += Vektor.List[i].Wert;
                }
            }
            return gesamtwert;
        }

        private int GetFitness()
        {
            if(GetGesamtmasse() > Constants.MAX_GEWICHT)
            {
                return 0;
            }

            return GetGesamtwert();
        }
    }
}