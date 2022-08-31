namespace Library.Domain.Common;
public class Payload<T> : PayloadBase
{
    public T? Item { get; private set; }

    public Payload(UserError error) : base(new[] { error })
    {

    }

    public Payload(T item)
    {
        Item = item;
    }
}
