namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta tipo { get ; private set; }
    public string numero  { get; private set; }
    public decimal saldo { get; protected set; }
    public Estado estado { get; protected set; }
    public decimal tasaDeInteres { get; private set; }
    public decimal limiteDeDescubierto{ get; private set; }
    public decimal comision {get; private set;}
    public string[] titulares { get; private set }

    public CuentaBancaria(string numero, decimal saldo)
    {
        numero = numero;
        saldo = saldo;
        estado = Estado.Activa;
    }

    public void Retirar(decimal monto)
    {
        if (tipo == TipoCuenta.CajaDeAhorro)
        {
            saldo -= monto;
        }
        else if (tipo == TipoCuenta.CuentaCorriente)
        {
            if (saldo - monto >= -limiteDeDescubierto)
            {
                saldo -= monto;
            }
            if (saldo < 0)
            {
                estado = Estado.Suspendida;
            }
        }
    }

    public void AplicarInteres()
    {
        if (tipo == TipoCuenta.CajaDeAhorro)
        {
            saldo += saldo * tasaDeInteres;
        }
    }
}
