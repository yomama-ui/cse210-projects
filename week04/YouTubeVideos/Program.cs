using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            var video1 = new Video("How to Cook Pasta", "Chef John", 300);
            var video2 = new Video("Learn Guitar in 10 Minutes", "MusicWithAmy", 600);
            var video3 = new Video("Top 10 Coding Tips", "CodeMaster", 450);

            video1.AddComment(new Comment("Alice", "Great recipe!"));
            video1.AddComment(new Comment("Bob", "Can't wait to try this."));
            video1.AddComment(new Comment("Charlie", "Looks delicious!"));

            video2.AddComment(new Comment("Dave", "Very helpful video."));
            video2.AddComment(new Comment("Eva", "I learned so much."));
            video2.AddComment(new Comment("Frank", "Awesome tutorial!"));

            video3.AddComment(new Comment("Grace", "These tips are gold."));
            video3.AddComment(new Comment("Hank", "Thank you for the advice."));
            video3.AddComment(new Comment("Isla", "This really helped me out."));

            List<Video> videos = new List<Video> { video1, video2, video3 };

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.GetTitle()}");
                Console.WriteLine($"Author: {video.GetAuthor()}");
                Console.WriteLine($"Length: {video.GetLength()} seconds");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
                }
                Console.WriteLine();
            }
        }
    }
}
