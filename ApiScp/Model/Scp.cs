namespace ApiScp.Model
{
    public class Scp
    {
        public int Id { get; set; }
        public string ItemNumber { get; set; }
        public string ObjectClass { get; set; }
        public string ContainmentProcedures { get; set; }
        public string Description { get; set; }

        //TODO adicionar a funcionalidade de update já que não faz muito sentido para isso agora

        //public void UpdateScp(string itemNumber, string objectClass, string containmentProcedures, string description)
        //{
        //    ItemNumber = itemNumber;
        //    ObjectClass = objectClass;
        //    ContainmentProcedures = containmentProcedures;
        //    Description = description;
        //}
    }
}
