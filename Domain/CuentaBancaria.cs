namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; private set; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public string[] Titulares { get; private set; }

    protected CuentaBancaria(string numero, decimal saldo)
    {
        this.Numero = numero;
        this.Saldo = saldo;
        this.Estado = Estado.Activa;
        this.Titulares = new string[] { };
    }

    public void EstablecerTitulares(string[] titulares)
    {
        this.Titulares = titulares;
    }

    public void EstadoCuenta(Estado estado)
    {
        this.Estado = estado;
    }

    public abstract void Retirar(decimal monto);
    public abstract void Depositar(decimal monto);
}