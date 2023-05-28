using DataMapper.Modle;
using DataMapper.Data_Mapper;
internal class Program
{
    private static void Main(string[] args)
    {
        
        string textToEnter = "Welcome to DataMapper Design Pattern Demo";
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        IDataMapper<Media> media_datamapper = new MediaDataMapper();
        Media media = new Media();
        IDataMapper<Student> student_datamapper = new StudentDataMapper();
        Student student = new Student();
        while (true)
        {
            Console.WriteLine("1. Add record \n2. Read By ID \n3. Delete Record \n4. Update Record \n5. Get All Records \n6. Exit");
            int func = Convert.ToInt32(Console.ReadLine());
            
            if (func == 1)
            {
                Console.WriteLine(" 1. Media Class \n 2. Student Class");
                int type_class = Convert.ToInt32(Console.ReadLine());
                if (type_class == 1)
                {
                    Console.WriteLine("NAME : ");
                    media.Name = Console.ReadLine();
                    Console.WriteLine("ID : ");
                    media.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Media_type? \n 0. Book \n 1. Magazine \n 2. Movie");
                    media.MediaType = (Media_type)Convert.ToInt32(Console.ReadLine());
                    media_datamapper.Save(media);
                }
                else if(type_class == 2)
                {
                    Console.WriteLine("NAME : ");
                    student.Name = Console.ReadLine();
                    Console.WriteLine("ID : ");
                    student.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Address : ");
                    student.Address = Console.ReadLine();
                    Console.Write("Date of Birth (e.g. 10/22/1987): ");
                    student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Grade : ");
                    student.Grade= Console.ReadLine(); 
                    student_datamapper.Save(student);
                }
            }
            else if (func == 2)
            {
                Console.WriteLine(" 1. Media Class \n 2. Student Class");
                int type_class = Convert.ToInt32(Console.ReadLine());
                if(type_class == 1)
                {
                    Console.WriteLine("ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    media=media_datamapper.GetById(id);
                    Console.WriteLine("Fetched Record: Name: " + media.Name + " Media_type: " + media.MediaType + " ID :" + media.Id);
                }
                else if (type_class == 2)
                {
                    Console.WriteLine("ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    student = student_datamapper.GetById(id);
                    Console.WriteLine("Fetched Record: Name: " + student.Name + " Grade : " + student.Grade + " ID :" + student.Id);
                }
            }
            else if (func == 3)
            {
                Console.WriteLine(" 1. Media Class \n 2. Student Class");
                int type_class = Convert.ToInt32(Console.ReadLine());
                if( type_class == 1)
                {
                    Console.WriteLine("ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool success =media_datamapper.Delete(id);
                    Console.WriteLine(success);
                }
                else if (type_class == 2)
                {
                    Console.WriteLine("ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool success = student_datamapper.Delete(id);
                }
            }
            else if (func == 4)
            {
                Console.WriteLine(" 1. Media Class \n 2. Student Class");
                int type_class = Convert.ToInt32(Console.ReadLine());
                if (type_class == 1)
                {
                    Console.WriteLine("NAME : ");
                    media.Name = Console.ReadLine();
                    Console.WriteLine("ID : ");
                    media.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Media_type? \n 0. Book \n 1. Magazine \n 2. Movie");
                    media.MediaType = (Media_type)Convert.ToInt32(Console.ReadLine());
                    media_datamapper.Update(media.Id, media);
                }
                else if(type_class == 2)
                {
                    Console.WriteLine("NAME : ");
                    student.Name = Console.ReadLine();
                    Console.WriteLine("ID : ");
                    student.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Address : ");
                    student.Address = Console.ReadLine();
                    Console.Write("Date of Birth (e.g. 10/22/1987): ");
                    student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Grade : ");
                    student.Grade = Console.ReadLine();
                    student_datamapper.Update(student.Id,student);
                }
            }
            else if(func == 5)
            {
                Console.WriteLine(" 1. Media Class \n 2. Student Class");
                int type_class = Convert.ToInt32(Console.ReadLine());
                if (type_class == 1)
                {
                    List<Media> medias = new List<Media>();
                    medias = media_datamapper.GetAll();
                    for(int i = 0; i < medias.Count; i++)
                    {
                        Console.WriteLine(medias[i].Name);
                    }
                }
                else if(type_class == 2)
                {
                    List<Student> students = new List<Student>();
                    students = student_datamapper.GetAll();
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine(students[i].Name);
                    }
                }
            }
            else if (func == 6)
            {
                break;
            }
        }
    }
}