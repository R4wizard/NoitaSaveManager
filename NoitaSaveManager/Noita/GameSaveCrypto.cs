using NoitaSaveManager.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NoitaSaveManager.Noita
{
    public struct CryptoKeyData
    {
        public byte[] IV;
        public byte[] Key;
    }

    public class GameSaveCrypto
    {
        public static void Encrypt(string path, string contents)
        {
            CryptoKeyData keyData = GetKeyData(Path.GetFileName(path));
            byte[] input = Encoding.ASCII.GetBytes(contents);
            byte[] output = new byte[input.Length];

            Aes128CounterMode aes = new Aes128CounterMode(keyData.IV);
            ICryptoTransform ict = aes.CreateEncryptor(keyData.Key, null);
            ict.TransformBlock(input, 0, input.Length, output, 0);

            File.WriteAllBytes(path, output);
        }

        public static string Decrypt(string path)
        {
            CryptoKeyData keyData = GetKeyData(Path.GetFileName(path));
            byte[] input = File.ReadAllBytes(path);
            byte[] output = new byte[input.Length];

            Aes128CounterMode aes = new Aes128CounterMode(keyData.IV);
            ICryptoTransform ict = aes.CreateEncryptor(keyData.Key, null);
            ict.TransformBlock(input, 0, input.Length, output, 0);
            return Encoding.ASCII.GetString(output);
        }

        private static CryptoKeyData GetKeyData(string filename)
        {
            string iv = "WhenYouHaveNothingLeftToSeek";
            string key = "PeopleWillRejoiceAndDance";
            switch (filename)
            {
                case "player.salakieli":
                    key = "WeSeeATrueSeekerOfKnowledge";
                    iv = "YouAreSoCloseToBeingEnlightened";
                    break;
                case "world_state.salakieli":
                    key = "TheTruthIsThatThereIsNothing";
                    iv = "MoreValuableThanKnowledge";
                    break;
                case "magic_numbers.salakieli":
                    key = "KnowledgeIsTheHighestOfTheHighest";
                    iv = "WhoWouldntGiveEverythingForTrueKnowledge";
                    break;
                case "_stats.salakieli":
                    key = "SecretsOfTheAllSeeing";
                    iv = "ThreeEyesAreWatchingYou";
                    break;
            }

            return new CryptoKeyData()
            {
                IV = Encoding.ASCII.GetBytes(iv.Substring(0, 16)),
                Key = Encoding.ASCII.GetBytes(key.Substring(0, 16))
            };
        }
    }
}
