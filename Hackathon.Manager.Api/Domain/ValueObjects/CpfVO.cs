using Hackathon.Manager.Api.Domain.Utils;

namespace Hackathon.Manager.Api.Domain.ValueObjects;

public struct CpfVO
{
    private readonly string _value;

    private CpfVO(string value)
    {
        value = CpfValidation.ClearCpf(value);

        _value = value;
    }

    public static CpfVO Parse(string value)
    {
        if (TryParse(value, out var result))
        {
            return result;
        }
        throw new ArgumentException();
    }

    public static bool TryParse(string value, out CpfVO cpf)
    {
        cpf = new CpfVO(value);
        return true;
    }

    public override string ToString() => _value;

    public static implicit operator CpfVO(string input) => Parse(input);
}