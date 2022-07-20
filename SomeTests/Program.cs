using Minio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SomeTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User firstUser = new User(new byte[] { }, new byte[] { }, "Mahmood", "Garibov");
            User commenter = new User(new byte[] { }, new byte[] { }, "Esqin", "Mahmudov");
            Video firstVideo = new Video
            {
                Source = new byte[] { },
                HashTags = new List<string> { "#yunanistan", "#türkiye", "#haf" },
                Title = "Yunanistan'ın Hava Kuvvetleri Ne Kadar Güçlü",
                ViewCount = 92390,
                LikeCount = 7600,
                DislikeCount = 23,
                Description = "Yunan Hava Kuvvetleri hangi uçaklara sahip? Rafale ve F-35 alımı Yunanistan'a nasıl bir avantaj sağlar? Yunan İHA ve SİHA'ları neler? Olası bir Türkiye - Yunanistan savaşının sonucu ne olur? ",
                PublishDate = DateTime.Now,
                Comments = new List<Comment> { new Comment("Salam basa dusmedim", 0, 0, DateTime.Now, commenter) },
                Owner = firstUser
            };

            Console.WriteLine("Your video : ");
            Console.WriteLine("This is video......");

            Console.WriteLine("Title: " + firstVideo.Title);
            Console.WriteLine($"Publish date : {firstVideo.PublishDate}                Like : {firstVideo.LikeCount}");
            Console.WriteLine($"Owner image : .....                FullName : {firstVideo.Owner.Name} {firstVideo.Owner.Surname}");
            Console.WriteLine($"Video description : {firstVideo.Description}");
            Console.WriteLine();

            foreach (Comment comment in firstVideo.Comments)
            {
                Console.WriteLine($"Comment owner: {comment.Owner.Name} {comment.Owner.Surname}");
                Console.WriteLine($"Comment date: {comment.CommentDate}");
                Console.WriteLine($"Text: {comment.Text}");
                Console.WriteLine($"Like count: {comment.LikeCount}");
            }



        }


        class User
        {
            public byte[] BackgroundImage { get; set; }
            public byte[] ProfileImage { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }

            public User(byte[] backgroundImage, byte[] profileImage, string name, string surname)
            {
                BackgroundImage = backgroundImage;
                ProfileImage = profileImage;
                Name = name;
                Surname = surname;
            }
        }

        class Video
        {
            public int Id { get; set; }
            public byte[] Source { get; set; }
            public List<string> HashTags { get; set; }
            public string Title { get; set; }
            public long ViewCount { get; set; }
            public long LikeCount { get; set; }
            public long DislikeCount { get; set; }
            public string Description { get; set; }
            public DateTime PublishDate { get; set; }
            public List<Comment> Comments { get; set; }
            public User Owner { get; set; }
        }

        class Comment
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public long LikeCount { get; set; }
            public long DislikeCount { get; set; }
            public bool IsLikedByVideoOwner { get; set; }
            public DateTime CommentDate { get; set; }
            public User Owner { get; set; }

            public Comment(string text, long likeCount, long dislikeCount, DateTime commentDate, User owner, bool isLikedByVideoOwner = false)
            {
                Text = text;
                LikeCount = likeCount;
                DislikeCount = dislikeCount;
                IsLikedByVideoOwner = isLikedByVideoOwner;
                CommentDate = commentDate;
                Owner = owner;
            }
        }
    }
}