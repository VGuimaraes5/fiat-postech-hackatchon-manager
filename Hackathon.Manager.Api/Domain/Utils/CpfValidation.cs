namespace Hackathon.Manager.Api.Domain.Utils;

public static class CpfValidation
{
    public static string ClearCpf(string cpf)
    {
        string clearCpf = cpf.Trim();
        clearCpf = clearCpf.Replace(".", "");
        clearCpf = clearCpf.Replace("-", "");

        return clearCpf;
    }

    public static bool ValidCpf(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            return false;

        string clearCpf = CpfValidation.ClearCpf(cpf);

        if (clearCpf.Length != 11)
            return false;

        var totalDigI = 0;
        var totalDigII = 0;

        switch (cpf)
        {
            case "00000000000":
            case "11111111111":
            case "22222222222":
            case "33333333333":
            case "44444444444":
            case "55555555555":
            case "66666666666":
            case "77777777777":
            case "88888888888":
            case "99999999999":
                return false;
        }

        foreach (char c in clearCpf)
        {
            if (!char.IsNumber(c))
                return false;
        }

        for (int position = 0; position < clearCpf.Length - 2; position++)
        {
            totalDigI += (clearCpf[position] - '0') * (10 - position);
            totalDigII += (clearCpf[position] - '0') * (11 - position);
        }

        var modI = totalDigI % 11;
        if (modI < 2) modI = 0;
        else modI = 11 - modI;

        if ((clearCpf[9] - '0') != modI)
            return false;

        totalDigII += modI * 2;

        var modII = totalDigII % 11;
        if (modII < 2) modII = 0;
        else modII = 11 - modII;

        if ((clearCpf[10] - '0') != modII)
            return false;

        return true;
    }
}