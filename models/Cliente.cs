namespace AgroSenseAPI.models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NmCliente { get; set; }
        public string TpCliente { get; set; }
        public DateTime? DtCadastro { get; set; }
        public string NmEmail { get; set; }
        public string NmSenha { get; set; }
    }
}
