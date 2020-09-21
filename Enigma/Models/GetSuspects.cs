﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Enigma.Models
{
    public class GetSuspects
    {
       

        public List<Suspect> GetAllSuspects(List<Suspect> Suspects)
        {
            Suspect suspect1 = new Suspect
            {
                Name = "Adam",
                Portrait = new BitmapImage(new Uri(@"\Assets\Images\image1.jpg", UriKind.Relative))
            };

            Suspects.Add(suspect1);

            Suspect suspect2 = new Suspect
            {
                Name = "Olga",
                Portrait = new BitmapImage(new Uri(@"\Assets\Images\image2.jpg", UriKind.Relative))
            };

            Suspects.Add(suspect2);

            Suspect suspect3 = new Suspect
            {
                Name = "Odam",
                Portrait = new BitmapImage(new Uri(@"\Assets\Images\image3.jpg", UriKind.Relative))
            };

            Suspects.Add(suspect3);

            Suspect suspect4 = new Suspect
            {
                Name = "Dani",
                Portrait = new BitmapImage(new Uri(@"\Assets\Images\image4.jpg", UriKind.Relative))
            };

            Suspects.Add(suspect4);

            return Suspects;
        }

        public List<Suspect> GetKiller(List<Suspect> anyList, List<Suspect> returnList)
        {
            //List<Suspect> tempList = new List<Suspect>();
            Random random = new Random();
            int index = random.Next(anyList.Count);
            returnList.Add(anyList[index]);

            return returnList;
        }

    }
}