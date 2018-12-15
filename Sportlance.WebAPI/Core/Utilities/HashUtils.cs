﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Sportlance.WebAPI.Core.Utilities
{
    public static class HashUtils
    {
        public static string CreateHash(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            var dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool CheckHash(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            var src = Convert.FromBase64String(hashedPassword);
            if (src.Length != 0x31 || src[0] != 0)
            {
                return false;
            }
            var dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            var buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(IReadOnlyList<byte> a, IReadOnlyList<byte> b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null || a.Count != b.Count) return false;
            var areSame = true;
            for (var i = 0; i < a.Count; i++) areSame &= a[i] == b[i];
            return areSame;
        }
    }
}