namespace POOREC.Models
{
    public class Participante : Usuario
    {
        public string ConfirmarChegada(){
            return "Confirmado em todos os dias";
        }

        public string ConfirmarData(){
            return "Data confirmada";
        }
    }
}