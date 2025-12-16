using System;

class StudentManager
{
    private Student[] students = new Student[50];
    private int count = 0;


    public void AddStudent(Student student)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == student.StudentId)
            {
                throw new ArgumentException("Mã sinh viên đã tồn tại");
            }
        }
        students[count++] = student;
    }

    public void RemoveStudent(String studentId)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == studentId)
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            throw new ArgumentException("Không tìm thấy sinh viên với mã đã cho");
        }
        for (int i = index; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }
        students[--count] = null;
    }

    public void UpdateScore(string studentId, double newScore)
    {
        Student student = null;
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == studentId)
            {
                student = students[i];
                break;
            }
        }
        if (student == null)
        {
            throw new ArgumentException("Không tìm thấy sinh viên với mã đã cho");
        }
        if (newScore < 0 || newScore > 10)
        {
            throw new ArgumentOutOfRangeException("Điểm phải nằm trong khoảng từ 0 đến 10");
        }
        student.Score = newScore;
    }

    public double GetAverageScore()
    {
        double totalScore = 0;
        for (int i = 0; i < count; i++)
        {
            totalScore += students[i].Score;
        }
        double averageScore = totalScore / count;
        return averageScore;
    }

    public double GetMaxScore()
    {
        if (count == 0)
        {
            return -1.0; // Hoặc ném ngoại lệ nếu bạn muốn
        }

        double maxScore = students[0].Score;
        for (int i = 1; i < count; i++)
        {
            if (students[i].Score > maxScore)
            {
                maxScore = students[i].Score;
            }
        }
        return maxScore;
    }

    public Student FindStudentById(string studentId)
    {
        Student student = null;
        for (int i = 0; i < count; i++)
        {
            if (students[i].StudentId == studentId)
            {
                student = students[i];
                break;
            }
        }
        return student;
    }

    public void DisplayAllStudents()
    {
        if (count == 0)
        {
            Console.WriteLine("Không có sinh viên nào để hiển thị.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            students[i].Display();
        }
    }
}