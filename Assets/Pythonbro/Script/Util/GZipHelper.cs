using System.IO;
using ICSharpCode.SharpZipLib.GZip;

public static class GZipHelper {

    public static int BUFFER_SIZE = 1024;

    public static byte[] Comperss(byte[] bytes) {
        using (MemoryStream output = new MemoryStream()) {
            using (MemoryStream input = new MemoryStream(bytes)) {
                using (GZipOutputStream stream = new GZipOutputStream(output)) {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int length;
                    while ((length = input.Read(buffer, 0, BUFFER_SIZE)) > 0) {
                        stream.Write(buffer, 0, length);
                    }
                }
            }
            return output.ToArray();
        }
    }

    public static byte[] Decompress(byte[] bytes) {
        using (MemoryStream output = new MemoryStream()) {
            using (MemoryStream input = new MemoryStream(bytes)) {
                using (GZipInputStream stream = new GZipInputStream(input)) {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int length;
                    while ((length = stream.Read(buffer, 0, BUFFER_SIZE)) > 0) {
                        output.Write(buffer, 0, length);
                    }
                }
            }
            return output.ToArray();
        }
    }

}
