﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public class SerializeDataSaver: IDataSaver
    {

        public List<T> Load<T>() where T : class 
        {
            var formatter = new BinaryFormatter();

            var fileName = typeof(T).Name;

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                if (file.Length > 0 && formatter.Deserialize(file) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class 
        {
            var formatter = new BinaryFormatter();

            var fileName = typeof(T).Name;

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, item);
            }
        }
    }
}
