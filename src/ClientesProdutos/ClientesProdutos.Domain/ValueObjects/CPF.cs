namespace ClientesProdutos.Domain.ValueObjects
{
    public static class CPFObject
    {
        public struct CPF
        {
            private readonly string _value;

            public readonly bool isValid;

            private CPF(string value)
            {
                _value = value;

                if (value == null)
                {
                    isValid = false;
                    return;
                }

                var posicao = 0;
                var totalDigito1 = 0;
                var totalDigito2 = 0;
                var dv1 = 0;
                var dv2 = 0;

                bool digitosIdenticos = true;
                var ultimoDigito = -1;

                foreach (var c in value)
                {
                    if (char.IsDigit(c))
                    {
                        var digito = c - '0';
                        if (posicao != 0 && ultimoDigito != digito)
                        {
                            digitosIdenticos = false;
                        }

                        ultimoDigito = digito;
                        if (posicao < 9)
                        {
                            totalDigito1 += digito * (10 - posicao);
                            totalDigito2 += digito * (11 - posicao);
                        }
                        else if (posicao == 9)
                        {
                            dv1 = digito;
                        }
                        else if (posicao == 10)
                        {
                            dv2 = digito;
                        }

                        posicao++;
                    }
                }

                if (posicao > 11)
                {
                    isValid = false;
                    return;
                }

                if (digitosIdenticos)
                {
                    isValid = false;
                    return;
                }

                var digito1 = totalDigito1 % 11;
                digito1 = digito1 < 2
                    ? 0
                    : 11 - digito1;

                if (dv1 != digito1)
                {
                    isValid = false;
                    return;
                }

                totalDigito2 += digito1 * 2;
                var digito2 = totalDigito2 % 11;
                digito2 = digito2 < 2
                    ? 0
                    : 11 - digito2;

                isValid = dv2 == digito2;
            }

            public static implicit operator CPF(string value)
                => new CPF(value);

            public override string ToString() => _value;
        }

        public static bool ValidarCPF(CPF sourceCPF) =>
            sourceCPF.isValid;
    }
}