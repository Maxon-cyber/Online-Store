using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Parameters;

public static class ID
{
    private const int COUNT_OF_INTS_ID = 8;

    public static ulong Create()
    {
        StringBuilder builderId = new StringBuilder();

        for (int count = 0; count < COUNT_OF_INTS_ID; count++)
            builderId.Append(new Random().Next(1, 9));

        ulong id = Convert.ToUInt64(builderId.ToString());

        builderId.Clear();

        return id;
    }
}