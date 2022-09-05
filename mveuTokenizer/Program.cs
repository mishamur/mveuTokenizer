using Tokenizers;


WordTokenizer wordTokenizer = new WordTokenizer();
wordTokenizer.ParseToToken("преумножить\\арвы127398мтыл{жабрие} 123 выарл 123 фйцл)предок}");
Console.WriteLine();

WordTokenChanger changer = new WordTokenChanger(wordTokenizer.GetTokens());
var tokens = changer.ChangeWord();
Console.WriteLine(string.Concat(tokens));




