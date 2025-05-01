namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; private set; }

        public CajaDeAhorro(string numero, decimal saldo) : base(numero, saldo)
        {
        }

        public override void Depositar(decimal monto)
        {
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            Saldo -= monto;
        }

        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }

        public void EstablecerTasaInteres(decimal tasa)
        {
            TasaDeInteres = tasa;
        }
    }
}