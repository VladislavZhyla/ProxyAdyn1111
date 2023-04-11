using System;
using System.Collections.Generic;

public interface IBankConsultant
{
    string GetAnswer(string question);
}

public class BankConsultant : IBankConsultant
{
    public string GetAnswer(string question)
    {
        switch (question.ToLower())
        {
            case "які зараз процентні ставки?":
                return "Поточні процентні ставки складають 2,5% для рахунків збережень та 4% для іпотеки";
            case "як я можу відкрити новий рахунок?":
                return "Ви можете відкрити новий рахунок, відвідавши будь-яке з наших відділень з вашим ідентифікаційним документом та документом, що підтверджує вашу адресу.";
            case "які комісії за міжнародні грошові перекази?":
                return "Комісії за міжнародні грошові перекази залежать від суми, що переказується, та країни призначення. Будь ласка, перевірте наш веб-сайт або відвідайте відділення для отримання додаткової інформації.";
            default:
                return "Вибачте, я не маю відповіді на це питання.";
        }
    }
}

public class BankConsultantProxy : IBankConsultant
{
    private BankConsultant consultant;
    private List<string> allowedQuestions;

    public BankConsultantProxy()
    {
        consultant = new BankConsultant();
        allowedQuestions = new List<string> {
            "які поточні процентні ставки?",
        "як я можу відкрити новий рахунок?",
        "які комісії за міжнародні грошові перекази?"
        };
    }

    public string GetAnswer(string question)
    {
        if (!allowedQuestions.Contains(question.ToLower()))
        {
            return "Вибачте, я не можу відповісти на це питання.";
        }
        else
        {
            return consultant.GetAnswer(question);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IBankConsultant consultant = new BankConsultantProxy();
        Console.WriteLine("Задайте питання банківському консультанту:");
        string question = Console.ReadLine();
        string answer = consultant.GetAnswer(question);
        Console.WriteLine(answer);
    }
}
