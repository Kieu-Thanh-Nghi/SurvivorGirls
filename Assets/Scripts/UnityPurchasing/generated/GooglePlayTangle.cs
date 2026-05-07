// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("TP9y3qer4kUBuwPKGI0kdLiM2iPhYmxjU+FiaWHhYmJj2yRRYYKbzjlsEvTn7HNgtiWwWE2okqo4rvBTVuvBPQZQVMogkigHa7L7mVnMSfvtumbli5oOxpWdNmPrsnIP28X86akbeRc2Ll+aPD3/TYhWemmh/pwAu+XInnZZ6JrhPgTtId2P070hqnFT4WJBU25laknlK+WUbmJiYmZjYCLf7sx0iCfYo851aMNUNTTZQZWSoddF3uqZEdu11eEOudhar9S1ETYBxyPXWyMY5Z8D1tv2mSLoX583LGpRy7Zk3Jq3aY9jzu2wOJML33F8h9EyznwzMiOe+oUdsbgpS0iEjoslkEZZ26GPLH0cscQhMvZXBNcsCk6KWt0YsjcVWmFgYmNi");
        private static int[] order = new int[] { 10,1,9,7,5,7,11,10,13,13,13,13,12,13,14 };
        private static int key = 99;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
