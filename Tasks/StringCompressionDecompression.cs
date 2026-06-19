namespace Tasks;

public class StringCompressionDecompression
{
	 public static string StringCompress(string strOrig)
        {
            string strCompressed = string.Empty;
            if(strOrig != null && strOrig.Length > 0)
            {
                strCompressed += strOrig[0].ToString();
                int i = 0,
                    count = 0;
                for(i = 1; i < strOrig.Length; i++)
                {
                    if(strOrig[i] == strOrig[i - 1])
                    {
                        count++;
                        if(i == strOrig.Length - 1)
                            strCompressed += (count + 1).ToString();
                    }
                    else
                    {
                        if(count > 0)
                        {
                            strCompressed += (count + 1).ToString();
                            count = 0;
                        }
                        strCompressed += strOrig[i];
                    }
                }
            }
            return strCompressed;
        }
      public static string StringDecompress(string strCompressed)
		{
			string strDecompressed = string.Empty;
			if(strCompressed != null && strCompressed.Length > 0)
			{
				int i = 0,
					j = 0,
                    curNumber = 0;
				string strNumber = string.Empty;
                for(i = 0; i < strCompressed.Length; i++)
				{
					if(strCompressed[i] >= '0' && strCompressed[i] <= '9')
					{
                        strNumber += strCompressed[i];
                        if(i == strCompressed.Length - 1)
                        {
                            if(strNumber != null && strNumber.Length > 0)
                            {
						        try
                                {
                                    curNumber = Convert.ToInt32(strNumber);
                                }
                                catch{}
						        for(j = 0; j < curNumber - 1; j++)
						        {
							        strDecompressed += strCompressed[i - (strNumber.Length)];
						        }
                            }
                        }
                    }
					else
					{
                        if(strNumber != null && strNumber.Length > 0)
                        {
						    try
                            {
                                curNumber = Convert.ToInt32(strNumber);
                            }
                            catch{}
						    for(j = 0; j < curNumber - 1; j++)
						    {
							    strDecompressed += strCompressed[i - (strNumber.Length + 1)];
						    }
                        }
                        strDecompressed += strCompressed[i];

                        curNumber = 0;
                        strNumber = string.Empty;
					}
				}
			}
			return strDecompressed;
		}
}
