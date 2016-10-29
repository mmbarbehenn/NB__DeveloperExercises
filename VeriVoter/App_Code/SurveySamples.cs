using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SurveySamples
/// </summary>
public class SurveySamples
{
    public static void RunSamples()
    {
        Survey s = CreateSurvey();
    }

    private static Survey CreateSurvey()
    {
        SurveyService surveyService = new SurveyService();
        Survey survey = CreateNewSurvey();

        surveyService.Create(ref survey);

        return survey;
    }

    private static Survey CreateNewSurvey()
    {
        Survey survey = new Survey();

        survey.Name = "Color/Name";
        survey.Slug = "Name2";
        survey.Title = "Color/Name Title";
        survey.Status = "published";

        survey.Questions = CreateQuestions();

        return survey;
    }

    private static List<SurveyQuestion> CreateQuestions()
    {
        List<SurveyQuestion> Questions = new List<SurveyQuestion>();

        //Question 1
        SurveyQuestion sq1 = new SurveyQuestion
        {
            Prompt = "What is your favorite color?",
            Slug = "fav-color-slug",
            Type = "multiple",
            Status = "published",
        };
        CreateQ1Choices(ref sq1);

        //Question 2
        SurveyQuestion sq2 = new SurveyQuestion
        {
            Prompt = "What is your name?",
            Slug = "name-slug",
            Type = "text",
            Status = "published",
        };

        Questions.Add(sq1);
        Questions.Add(sq2);

        return Questions;
    }

    private static void CreateQ1Choices(ref SurveyQuestion sq1)
    {
        List<SurveyQuestionChoices> choices = new List<SurveyQuestionChoices>();

        SurveyQuestionChoices sqc1 = new SurveyQuestionChoices { Name = "Blue" };
        SurveyQuestionChoices sqc2 = new SurveyQuestionChoices { Name = "Green" };
        SurveyQuestionChoices sqc3 = new SurveyQuestionChoices { Name = "Red" };

        choices.Add(sqc1);
        choices.Add(sqc2);
        choices.Add(sqc3);
        sq1.Choice = choices;
    }
}