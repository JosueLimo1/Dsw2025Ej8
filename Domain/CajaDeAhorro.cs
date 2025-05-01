using Dsw2025Ej8.Domain.Exceptions;

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
            if (monto <= 0)
                throw new MontoNoValidoException();
            
            if (Estado != Estado.Activa) 
                throw new CuentaNoActivaException(Estado);

            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new MontoNoValidoException();

            Saldo -= monto;

            if (Estado != Estado.Activa) 
                throw new CuentaNoActivaException(Estado);

            if (Saldo < monto)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
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