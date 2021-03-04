namespace cadastro_de_series
{
    /*classe abstrata - para que todas as class que herdarem,
     possa ter um id */
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}