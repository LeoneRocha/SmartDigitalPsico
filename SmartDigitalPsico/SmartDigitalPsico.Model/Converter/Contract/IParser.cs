using System.Collections.Generic;

namespace SmartDigitalPsico.Model.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
