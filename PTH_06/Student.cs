using System;
using System.Text;

public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }

    //Hàm tạo (Constructor) của lớp Student
    public Student(string studentId, string name, double score)
    {
        if(string.IsNullOrEmpty(studentId))
        {
            throw new ArgumentException("Student ID không được để trống");
        }
        this.StudentId = studentId;
        if(string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Tên không được để trống");
        }
        this.Name = name;
        if(score < 0 || score > 10)
        {
            throw new ArgumentOutOfRangeException("Điểm phải nằm trong khoảng từ 0 đến 10");
        }
        this.Score = score;
    }

    // Phương thức Display để hiển thị thông tin sinh viên
    public void Display()
        {
            Console.WriteLine($"Student ID: {StudentId}| Name: {Name}| Score: {Score}");
        }
}