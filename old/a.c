import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

public class Main {

	/**
	 * @param args
	 * @throws InterruptedException
	 * @throws UnsupportedEncodingException
	 */
	public static void main(String[] args) throws InterruptedException,
			UnsupportedEncodingException {
		// TODO Auto-generated method stub
		// System.err.println(args[0] + "," + args[1]);
		String basecmd = "\"D:\\Program Files\\Subversion\\bin\\svnlook.exe\"";
		String changeCmd = basecmd + " changed -t " + args[1] + " " + args[0];

		String result = runCmd(changeCmd);
		String[] files = result.split("\n");
		List<TypeFile> typeFiles = new ArrayList<>();
		for (String file : files) {
			String name = file.split(" ")[file.split(" ").length - 1].trim();
			if (name.endsWith(".c") || name.endsWith(".cpp")
					|| name.endsWith(".h") || name.endsWith(".inc")) {
				TypeFile typeFile = new TypeFile();
				typeFile.type = file.split(" ")[0];
				// System.err.println(typeFile.type);
				typeFile.fileName = name;
				if (typeFile.type.equals("U") || typeFile.type.equals("A")) {
					String changeInfocmd = basecmd + " cat -t " + args[1] + " "
							+ args[0] + name;

					typeFile.change = runCmd(changeInfocmd);
					typeFiles.add(typeFile);
				}
			}

		}

		System.exit(judgeResult(typeFiles));
	}

	private static int judgeResult(List<TypeFile> typeFiles)
			throws UnsupportedEncodingException {
		String errString = "以下文件存在注释不规范";
		int ret = 0;
		for (TypeFile typeFile : typeFiles) {
			String lns[] = typeFile.change.split("\n");
			for (String ln : lns) {

				String ecode = getEncoding(ln);
				System.err.println(ecode);
				ln = new String(ln.getBytes(ecode), "GBK");
				System.err.println(ln);
				ln = ln.trim();
				if (ln.startsWith("/*")
						&& !(ln.startsWith("/**") || ln.startsWith("/* "))) {
					errString += "\n" + typeFile.fileName;
					ret = 1;
					// System.err.println("1" + ln + ln.startsWith("/*")
					// + ln.startsWith("/**") + ln.startsWith("/* "));
					continue;
				}
				if (ln.endsWith("*/")
						&& !(ln.endsWith("**/") || ln.endsWith(" */"))) {
					errString += "\n" + typeFile.fileName;
					ret = 1;
					// System.err.println("2" + ln + ln.endsWith("*/")
					// + ln.endsWith("**/") + ln.endsWith(" */"));
				}
			}
		}
		/*我是注释 */
		if (ret == 1) {
			System.err.println(errString);
			System.err.println("不规范注释示例：/*我是注释*/");
			System.err.println("规范注释示例：/* 我是注释 */");
		}
		return ret;
	}

	/*服务器*/
	public static String getEncoding(String str) {
		String encode = "ISO-8859-1";
		try {
			if (str.equals(new String(str.getBytes(encode), encode))) {
				String s = encode;
				return s;
			}
		} catch (Exception exception) {
		}
		encode = "GB2312";
		try {
			if (str.equals(new String(str.getBytes(encode), encode))) {
				String s1 = encode;
				return s1;
			}
		} catch (Exception exception1) {
		}
		encode = "GBK";
		try {
			if (str.equals(new String(str.getBytes(encode), encode))) {
				String s2 = encode;
				return s2;
			}
		} catch (Exception exception2) {
		}
		encode = "UTF-8";
		try {
			if (str.equals(new String(str.getBytes(encode), encode))) {
				String s3 = encode;
				return s3;
			}
		} catch (Exception exception3) {
		}
		return "";
	}

	private static String runCmd(String changeCmd) {
		// System.err.println(changeCmd);
		Runtime run = Runtime.getRuntime();
		Process process = null;
		String result = null;
		try {
			process = run.exec(changeCmd);

			ByteArrayOutputStream resultOutStream = new ByteArrayOutputStream();

			InputStream errorInStream = new BufferedInputStream(
					process.getErrorStream());

			InputStream processInStream = new BufferedInputStream(
					process.getInputStream());

			int num = 0;

			byte[] bs = new byte[1024];

			while ((num = errorInStream.read(bs)) != -1) {

				resultOutStream.write(bs, 0, num);

			}

			while ((num = processInStream.read(bs)) != -1) {

				resultOutStream.write(bs, 0, num);

			}

			result = new String(resultOutStream.toByteArray());

			// System.err.println(result);

			errorInStream.close();
			errorInStream = null;

			processInStream.close();
			processInStream = null;

			resultOutStream.close();
			resultOutStream = null;

		} catch (IOException e) {

			e.printStackTrace();

		} finally {

			if (process != null)
				process.destroy();

			process = null;

		}
		return result;
	}
}

class TypeFile {
	String type;
	String fileName;
	String change;
}
