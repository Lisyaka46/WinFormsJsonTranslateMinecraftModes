using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WinFormsJsonTranslateMinecraftModes
{
    /// <summary>
    /// Translates text using Google's online language tools.
    /// </summary>
    public class Translator
    {
        #region Public methods

        /// <summary>
        /// Перевод текста на любой язык
        /// </summary>
        /// <param name="sourceText">Переводимый текст</param>
        /// <param name="sourceLanguage">Язык на котором написан текст для перевода {en}</param>
        /// <param name="targetLanguage">Язык на который переводится текст {ru}</param>
        /// <returns>Переведённый текст</returns>
        public static string Translate(string sourceText, string sourceLanguage, string targetLanguage)
        {
            string TextTranslation = string.Empty;

            try
            {
                // Download translation
                string url = string.Format(
                    $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targetLanguage}&dt=t&q={HttpUtility.UrlEncode(sourceText)}");
                string outputFile = Path.GetTempFileName();

#pragma warning disable SYSLIB0014 // Тип или член устарел
                using (WebClient wc = new())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.DownloadFile(url, outputFile);
                }
#pragma warning restore SYSLIB0014 // Тип или член устарел

                // Get translated text
                if (File.Exists(outputFile))
                {

                    // Get phrase collection
                    string text = File.ReadAllText(outputFile);
                    int index = text.IndexOf(string.Format($",,\"{sourceLanguage}\""));
                    if (index == -1)
                    {
                        // Translation of single word
                        int startQuote = text.IndexOf('\"');
                        if (startQuote != -1)
                        {
                            int endQuote = text.IndexOf('\"', startQuote + 1);
                            if (endQuote != -1)
                            {
                                TextTranslation = text.Substring(startQuote + 1, endQuote - startQuote - 1);
                            }
                        }
                    }
                    else
                    {
                        // Translation of phrase
                        text = text[..index];
                        text = text.Replace("],[", ",");
                        text = text.Replace("]", string.Empty);
                        text = text.Replace("[", string.Empty);
                        text = text.Replace("\",\"", "\"");

                        // Get translated phrases
                        string[] phrases = text.Split(new char['\"'], StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < phrases.Length; i += 2)
                        {
                            string translatedPhrase = phrases[i];
                            if (translatedPhrase.StartsWith(",,"))
                            {
                                i--;
                                continue;
                            }
                            TextTranslation += translatedPhrase + "  ";
                        }
                    }

                    // Fix up translation
                    TextTranslation = TextTranslation.Trim();
                    TextTranslation = TextTranslation.Replace(" ?", "?");
                    TextTranslation = TextTranslation.Replace(" !", "!");
                    TextTranslation = TextTranslation.Replace(" ,", ",");
                    TextTranslation = TextTranslation.Replace(" .", ".");
                    TextTranslation = TextTranslation.Replace(" ;", ";");
                }
            }
            catch
            {
            }

            // Return result
            return TextTranslation;
        }

        #endregion

        /*
        Translator._languageModeMap = new Dictionary<string, string>();
        Translator._languageModeMap.Add("Afrikaans", "af");
        Translator._languageModeMap.Add("Albanian", "sq");
        Translator._languageModeMap.Add("Arabic", "ar");
        Translator._languageModeMap.Add("Armenian", "hy");
        Translator._languageModeMap.Add("Azerbaijani", "az");
        Translator._languageModeMap.Add("Basque", "eu");
        Translator._languageModeMap.Add("Belarusian", "be");
        Translator._languageModeMap.Add("Bengali", "bn");
        Translator._languageModeMap.Add("Bulgarian", "bg");
        Translator._languageModeMap.Add("Catalan", "ca");
        Translator._languageModeMap.Add("Chinese", "zh-CN");
        Translator._languageModeMap.Add("Croatian", "hr");
        Translator._languageModeMap.Add("Czech", "cs");
        Translator._languageModeMap.Add("Danish", "da");
        Translator._languageModeMap.Add("Dutch", "nl");
        Translator._languageModeMap.Add("English", "en");
        Translator._languageModeMap.Add("Esperanto", "eo");
        Translator._languageModeMap.Add("Estonian", "et");
        Translator._languageModeMap.Add("Filipino", "tl");
        Translator._languageModeMap.Add("Finnish", "fi");
        Translator._languageModeMap.Add("French", "fr");
        Translator._languageModeMap.Add("Galician", "gl");
        Translator._languageModeMap.Add("German", "de");
        Translator._languageModeMap.Add("Georgian", "ka");
        Translator._languageModeMap.Add("Greek", "el");
        Translator._languageModeMap.Add("Haitian Creole", "ht");
        Translator._languageModeMap.Add("Hebrew", "iw");
        Translator._languageModeMap.Add("Hindi", "hi");
        Translator._languageModeMap.Add("Hungarian", "hu");
        Translator._languageModeMap.Add("Icelandic", "is");
        Translator._languageModeMap.Add("Indonesian", "id");
        Translator._languageModeMap.Add("Irish", "ga");
        Translator._languageModeMap.Add("Italian", "it");
        Translator._languageModeMap.Add("Japanese", "ja");
        Translator._languageModeMap.Add("Korean", "ko");
        Translator._languageModeMap.Add("Lao", "lo");
        Translator._languageModeMap.Add("Latin", "la");
        Translator._languageModeMap.Add("Latvian", "lv");
        Translator._languageModeMap.Add("Lithuanian", "lt");
        Translator._languageModeMap.Add("Macedonian", "mk");
        Translator._languageModeMap.Add("Malay", "ms");
        Translator._languageModeMap.Add("Maltese", "mt");
        Translator._languageModeMap.Add("Norwegian", "no");
        Translator._languageModeMap.Add("Persian", "fa");
        Translator._languageModeMap.Add("Polish", "pl");
        Translator._languageModeMap.Add("Portuguese", "pt");
        Translator._languageModeMap.Add("Romanian", "ro");
        Translator._languageModeMap.Add("Russian", "ru");
        Translator._languageModeMap.Add("Serbian", "sr");
        Translator._languageModeMap.Add("Slovak", "sk");
        Translator._languageModeMap.Add("Slovenian", "sl");
        Translator._languageModeMap.Add("Spanish", "es");
        Translator._languageModeMap.Add("Swahili", "sw");
        Translator._languageModeMap.Add("Swedish", "sv");
        Translator._languageModeMap.Add("Tamil", "ta");
        Translator._languageModeMap.Add("Telugu", "te");
        Translator._languageModeMap.Add("Thai", "th");
        Translator._languageModeMap.Add("Turkish", "tr");
        Translator._languageModeMap.Add("Ukrainian", "uk");
        Translator._languageModeMap.Add("Urdu", "ur");
        Translator._languageModeMap.Add("Vietnamese", "vi");
        Translator._languageModeMap.Add("Welsh", "cy");
        Translator._languageModeMap.Add("Yiddish", "yi");
        */
    }
}
