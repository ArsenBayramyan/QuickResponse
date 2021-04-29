using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponse.Core.Helpers
{
    public static class CodingDecodingHelper
    {
        public static string CodeingCaesar(this string value)
        {
            if (value == null)
            {
                return null;
            }
            List<char> originList = new List<char>()
                        { 'A','B','C','D','E','F','G','H','I','J','K','L','M',
                          'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',' ',',',':',';',')','(','.','@','?','!',Convert.ToChar("'"),
                          'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
                          'p','q','r','s','t','u','v','w','x','y','z','1','2','3','4','5','6','7','8','9','0',
                          'Ա','Բ','Գ','Դ','Ե','Զ','Է','Ը','Թ','Ժ','Ի','Լ','Խ','Ծ','Կ','Հ','Ձ','Ղ','Ճ','Մ','Յ','Ն','Շ','Ո','Չ','Պ','Ջ','Ռ','Ս','Վ',
                          'Տ','Ր','Ց','Ւ','Փ','Ք','Օ','Ֆ','ա','բ','գ','դ','ե','զ','է','ը','թ','ժ','ի','լ','խ','ծ','կ','հ','ձ','ղ','ճ','մ','յ','ն','շ','ո','չ','պ','ջ','ռ','ս','վ','տ',
                          'ր','ց','ւ','փ','ք','և','օ','ֆ'
                        };
            List<char> codeList = new List<char>()
                               { 'D','E','F','G','H','I','J','K','L','M',
                                 'N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','$','#','*',')','/','%','(','-',
                                 'd','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','~','!','`',
                                 'v','w','x','y','z','a','b','c','4','5','6','7','8','9','0','1','2','3',
                                 'Ե','Զ','Է','Ը','Թ','Ժ','Ի','Լ','Խ','Ծ','Կ','Հ','Ձ','Ղ','Ճ','Մ','Յ','Ն','Շ','Ո','Չ','Պ','Ջ','Ռ','Ս','Վ',
                                 'Տ','Ր','Ց','Ւ','Փ','Ք','Օ','Ֆ','Ա','Բ','Գ','Դ','ե','զ','է','ը','թ','ժ','ի','լ','խ','ծ','կ','հ','ձ','ղ','ճ','մ','յ','ն','շ','ո','չ','պ','ջ','ռ','ս','վ','տ',
                                 'ր','ց','г','փ','ք','և','օ','ֆ','ա','բ','գ','դ'
                               };
            int index = 0;
            List<char> outputList = new List<char>();
            for (int i = 0; i < value.Length; i++)
            {
                index = originList.IndexOf(value[i]);
                outputList.Add(codeList[index]);
            }
            return CodingWithMatrix(new string(outputList.ToArray()));
        }
        public static string DecodingWithMatrix(this string value)
        {
            if (value == null)
            {
                return null;
            }
            var size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(value.Length)));
            var matrix = new char[size, size];
            var index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = value[index];
                    index++;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            var output = new List<char>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output.Add(matrix[i, j]);
                }
            }
            output.Reverse();
            var lastIndex = 0;

            foreach (var item in output)
            {
                if (item == ' ')
                {
                    lastIndex++;
                }
                else
                {
                    break;
                }
            }
            output.RemoveRange(0, lastIndex);
            output.Reverse();

            return DecodingCaesar(new string(output.ToArray()));
        }
        private static string CodingWithMatrix(string value)
        {
            var size = Convert.ToInt32(Math.Ceiling(Math.Sqrt(value.Length)));
            var matrix = new char[size, size];
            var index = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (index < value.Length)
                    {
                        matrix[i, j] = value[index];
                        index++;
                    }
                    else
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            var output = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output.Append(matrix[i, j].ToString());
                }
            }

            return output.ToString();
        }
        private static string DecodingCaesar(string output)
        {
            List<char> originList = new List<char>()
                         { 'A','B','C','D','E','F','G','H','I','J','K','L','M',
                          'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',' ',',',':',';',')','(','.','@','?','!',Convert.ToChar("'"),
                          'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
                          'p','q','r','s','t','u','v','w','x','y','z','1','2','3','4','5','6','7','8','9','0',
                          'Ա','Բ','Գ','Դ','Ե','Զ','Է','Ը','Թ','Ժ','Ի','Լ','Խ','Ծ','Կ','Հ','Ձ','Ղ','Ճ','Մ','Յ','Ն','Շ','Ո','Չ','Պ','Ջ','Ռ','Ս','Վ',
                          'Տ','Ր','Ց','Ւ','Փ','Ք','Օ','Ֆ','ա','բ','գ','դ','ե','զ','է','ը','թ','ժ','ի','լ','խ','ծ','կ','հ','ձ','ղ','ճ','մ','յ','ն','շ','ո','չ','պ','ջ','ռ','ս','վ','տ',
                          'ր','ց','ւ','փ','ք','և','օ','ֆ'
                        };
            List<char> codeList = new List<char>()
                               { 'D','E','F','G','H','I','J','K','L','M',
                                 'N','O','P','Q','R','S','T','U','V','W','X','Y','Z','A','B','C','$','#','*',')','/','%','(','-',
                                 'd','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','~','!','`',
                                 'v','w','x','y','z','a','b','c','4','5','6','7','8','9','0','1','2','3',
                                 'Ե','Զ','Է','Ը','Թ','Ժ','Ի','Լ','Խ','Ծ','Կ','Հ','Ձ','Ղ','Ճ','Մ','Յ','Ն','Շ','Ո','Չ','Պ','Ջ','Ռ','Ս','Վ',
                                 'Տ','Ր','Ց','Ւ','Փ','Ք','Օ','Ֆ','Ա','Բ','Գ','Դ','ե','զ','է','ը','թ','ժ','ի','լ','խ','ծ','կ','հ','ձ','ղ','ճ','մ','յ','ն','շ','ո','չ','պ','ջ','ռ','ս','վ','տ',
                                 'ր','ց','г','փ','ք','և','օ','ֆ','ա','բ','գ','դ'
                               };
            List<char> word = new List<char>();
            int index = 0;
            for (int i = 0; i < output.Length; i++)
            {
                index = codeList.IndexOf(output[i]);
                word.Add(originList[index]);
            }
            return new string(word.ToArray());
        }
    }
}

