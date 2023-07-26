using System.Reflection.PortableExecutable;

namespace Task5
{
    class Question
    {
        public int Mark { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string CorrectAnswer { get; set; }
        public Question(string Header, string Body, int Mark)
        {
            this.Mark = Mark;
            this.Body = Body;
            this.Header = Header;
        }
        public Question(string Header, string Body, string correctAnswer, int Mark):this(Header, Body, Mark)
        {
           
            CorrectAnswer = correctAnswer;

        }
        public virtual void Display()
        {
            Console.WriteLine($"{Header}.\t\tMark: {Mark}.\n{Body}");
        }


    }
    class MCQ:Question
    {
        public string[] Chooses { get; set; }
        public MCQ(string[] Chooses, string Header, string Body, int Mark) : base(Header, Body, Mark)
        {
            this.Chooses = Chooses;
        }
        public MCQ(string[] Chooses, string Header, string Body, string correctanswer,int Mark):base(Header, Body, correctanswer, Mark)
        {
           this.Chooses= Chooses;
        }
        public override void Display()
        {
            base.Display();
            for(int i= 0;i< Chooses.Length; i++)
                Console.WriteLine($"{i+1}. {Chooses[i]}.\n");
        }
    }
    class TrueOrFalse:Question
    {
        //public bool True { get; set; }
        public TrueOrFalse(string Header, string Body, int Mark) : base(Header, Body, Mark)
        {

        }
        public TrueOrFalse(string Header, string Body,string correctanswer, int Mark):base(Header,Body, correctanswer, Mark)
        {
            //this.True = True;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"1.True.\n2.False.\n");
        }
    }

   


        internal class Program
        {
        public static void Write_Exam(int num_of_question, Question[] questions)
        {
            //questions=new Question[num_of_question];
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine("enter the type of Question you need MCQ or TrueOrFalse!");
                string TypeOfQuestion = Console.ReadLine();
                switch (TypeOfQuestion)
                {
                    case "MCQ":
                        string[] header_body_mark = Write_Question();
                        string[] chooses_choose = Chooses();
                        Console.WriteLine("Enter the correct answer to this question");
                        string correctans = Console.ReadLine();
                        for (int z = i; z < questions.Length; z++)
                        {
                            questions[z] = new MCQ(chooses_choose, header_body_mark[0], header_body_mark[1], correctans, int.Parse(header_body_mark[2]));
                        }
                        break;
                    case "TrueOrFalse":
                        string[] header_body_mark_T = Write_Question();
                        Console.WriteLine("Enter the correct answer to this question");
                        string correctans_T = Console.ReadLine();
                        for (int x = i; x < questions.Length; x++)
                        {
                            questions[x] = new TrueOrFalse(header_body_mark_T[0], header_body_mark_T[1], correctans_T, int.Parse(header_body_mark_T[2]));
                        }
                        break;
                }
            }

        }
        public static string[] Write_Question()
        {
            Console.WriteLine("Enter header of this question");
             string header = Console.ReadLine();
            Console.WriteLine("Enter mark of this question");
            string mark = Console.ReadLine();
            Console.WriteLine("Enter body of this question");
             string body = Console.ReadLine();
            string[] questions = { header, body ,mark};
            return questions;

        }
        public static string[]Chooses()
        {
            Console.WriteLine("Enter Number of chooses of answer to this question");
            int NumOfChooses = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter chooses of answer to this question");
            string[] chooses = new string[NumOfChooses];
            for (int j = 0; j < chooses.Length; j++)
                chooses[j] = Console.ReadLine();
            return chooses;
        }
        public static void Display_Exam(Question[] questions )
        {
            Console.WriteLine("\n.................This is Your Exam..............");
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].Display();
            }
        }
        public static int Solve_Exam(Question[] questions)
        {
            Console.WriteLine("Please Answer Your Exam");
            int grade = 0;
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"enter your answer for question {i + 1}");
                string ans =Console.ReadLine();
                if (ans.ToLower() == questions[i].CorrectAnswer)
                {
                    grade += questions[i].Mark;
                }

            }
            return grade;
        }
        static void Main(string[] args)
        {

            #region Task1
            //Console.WriteLine("..................Class Question............");
            //Question question = new Question("First Question", "anything", 50);
            //question.Display();
            //Console.WriteLine();

            ////..................................................
            //string headerForChoose = "Choose The Correct answer";
            //string bodyForChoose = "class is a ......";
            //string[] chooses = { "Reference type", "value type" };
            //Console.WriteLine(".............Class MCQ............");
            //MCQ mCQ = new MCQ(chooses, headerForChoose, bodyForChoose, 50);
            //mCQ.Display();

            ////.....................................................
            //Console.WriteLine("..................Class TOF............");
            //string headerForToF = "True Or Fasle question";
            //string bodyForToF = "class is a Reference type?";
            //TrueOrFalse trueOrFalse = new TrueOrFalse(headerForToF, bodyForToF, 50);
            //trueOrFalse.Display();
            #endregion
            #region Task2
            //string headerForChoose = "Choose The Correct answer";
            //Question[] question = new Question[2];
            //string bodyForChoose = "class is a ......";
            //string[] chooses = { "Reference type", "value type" };
            //question[0] = new MCQ(chooses, headerForChoose, bodyForChoose, 50);
            //string headerForToF = "True Or Fasle question";
            //string bodyForToF = "class is a Reference type?";
            //question[1] = new TrueOrFalse(headerForToF, bodyForToF, 50);

            //for (int i = 0; i < question.Length; i++)
            //{
            //    question[i].Display();
            //}
            #endregion
            #region Bouns
            Console.WriteLine("Enter Number of Your Question");
            int NumberOfQuestion = int.Parse(Console.ReadLine());
            Question[] question = new Question[NumberOfQuestion];
            Write_Exam(NumberOfQuestion, question);
            Display_Exam(question);
            int Result = Solve_Exam(question);
            Console.WriteLine($"Your Grade is: {Result}");
            #endregion


        }  
    }
}