using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = ToWordList(text);
    }

    public void HideRandomWords(int numberToHide)
    {
        int times = 0;
        while (times < numberToHide) {
            Random random = new Random();
            int randomNumber = random.Next(_words.Count);

            Word wordRandomSelected = _words[randomNumber];
            if (wordRandomSelected.IsHidden())
            {
                continue;
            }
            wordRandomSelected.Hide();
            times++;
        }
    }

    public string GetDisplay()
    {
        string reference = _reference.GetDisplayText();
        string text = "";
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden())
            {
                text += underscores(_words[i].GetDisplayText());
            } else
            {
                text += _words[i].GetDisplayText();
            }

            if (i < _words.Count - 1)
            {
                text += " ";
            }
        }
        return $"{reference} {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    private List<Word> ToWordList(string text)
    {
        string[] scriptureArray = text.Split(" ");
        List<Word> wordsList = new List<Word>();

        foreach (string expresion in scriptureArray)
        {
            Word word = new Word(expresion);
            wordsList.Add(word);
        }

        return wordsList;
    }

    private string underscores(string word) {
        int numberCharacters = word.Length;
        string guionesBajos = new string('_', numberCharacters);
        return guionesBajos;
    }
}