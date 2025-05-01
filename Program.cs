using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>(); //Lista para las cuentas que voy a crear

            //Instancio 4 cuentas 
            var ahorro1 = new CajaDeAhorro("CA000001", 1000);
            ahorro1.EstablecerTasaInteres(0.05m);
            ahorro1.EstablecerTitulares(new string[] { "Josue Limo", "Ignacio Hillen" });

            var ahorro2 = new CajaDeAhorro("CA000005", 2000);
            ahorro2.EstablecerTasaInteres(0.03m);
            ahorro2.EstablecerTitulares(new string[] { "Nicolas Quinteros" });

            var corriente1 = new CuentaCorriente("CC000011", 500);
            corriente1.EstablecerLimiteDescubierto(300);
            corriente1.EstablecerTitulares(new string[] { "Julian Alvarez", "Alexis Mac Allister" });

            var corriente2 = new CuentaCorriente("CC000008", 1500);
            corriente2.EstablecerLimiteDescubierto(500);
            corriente2.EstablecerTitulares(new string[] { "Lionel Messi" });
            corriente2.EstadoCuenta(Estado.Inactiva);

            cuentas.Add(ahorro1);
            cuentas.Add(ahorro2);
            cuentas.Add(corriente1);
            cuentas.Add(corriente2);

            void Operar(Action operacion)
            {
                try
                {
                    operacion(); //Ejecuta todo
                }
                catch (Exception ex) //Agarro la excepción pero no pauso el programa
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }

            //Operaciones 
            Operar(() => ahorro1.Depositar(200));
            Operar(() => ahorro1.Retirar(50));
            Operar(() => ahorro1.AplicarInteres()); //Teóricamente todo bien

            Operar(() => ahorro2.Retirar(0)); //Monto no válido
            Operar(() => ahorro2.Retirar(3000)); //Saldo insuficiente

            Operar(() => corriente1.Retirar(500)); //Entra en descubierto válido
            Operar(() => corriente1.Depositar(100));
            Operar(() => corriente1.Retirar(200)); //Supera límite pero sigue dentro del descubierto permitido

            Operar(() => corriente2.Depositar(500));
            Operar(() => corriente2.Retirar(2000)); //Justo al límite, todo bien

            //Resumen con titulares
            foreach (var cuenta in cuentas) //Recorro toda la lista
            {
                var resumen = new //Variable anónima que pide la consigna
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado,
                    Titulares = string.Join(", ", cuenta.Titulares)
                };

                Console.WriteLine($"Cuenta {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: {resumen.Saldo:C} | Estado: {resumen.Estado} | Titulares: {resumen.Titulares}");
            }

        }
    }
}
    