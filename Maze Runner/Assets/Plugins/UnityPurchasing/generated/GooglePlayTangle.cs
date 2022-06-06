#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("2AaZrlNGPuehURA5xV+cijdZ8ju5EYiFALsGfkSjMgkME9xZgP1QETiUVAzHAw/xUNehPkl96ZoGHmJH4i0N/eBZ9sZf3fmY+O+Nujux8fNjMJzqwazPBqPcjV4Xckytn6Ix8fJxf3BA8nF6cvJxcXDih9PypV1y+TC5Co7y/LhrAnA/8SQElbF3JVxWjx4ddMNG7jPZ55KzoyfWatO01Y7zkkLZXAvwklbvlMgngCLQEaYTAHhLW0LaArVEBJ9LElE1r6KOxykZkmPX3nV/4ztK806EfGrmJihv+J0RI1Q64AqiR6PRMhcVvnAQhXPkQPJxUkB9dnla9jj2h31xcXF1cHNQnUt+54tHonjET0xUTJEFSmA9QtLDjPoK61XizXJzcXBx");
        private static int[] order = new int[] { 7,10,11,3,12,10,10,12,8,11,11,13,12,13,14 };
        private static int key = 112;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
