using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain.Exceptions;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto { get; private set; }
        public decimal Comision { get; private set; }

        public CuentaCorriente(string numero, decimal saldo) : base(numero, saldo)
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

            if (Estado != Estado.Activa)
                throw new CuentaNoActivaException(Estado);

            if (Saldo - monto < -LimiteDeDescubierto)
                {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
                }

            Saldo -= monto;

            if (Saldo < -LimiteDeDescubierto)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException();
            }
        }

        public void EstablecerLimiteDescubierto(decimal limite)
        {
            LimiteDeDescubierto = limite;
        }
    }
}