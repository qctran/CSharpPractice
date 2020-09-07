﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateIPAddress
{
    /*
        Write a function to check whether an input string is a valid IPv4 address or IPv6 address or neither.

        IPv4 addresses are canonically represented in dot-decimal notation, which consists of four decimal numbers, each ranging from 0 to 255, separated by dots ("."), e.g.,172.16.254.1;

        Besides, leading zeros in the IPv4 is invalid. For example, the address 172.16.254.01 is invalid.

        IPv6 addresses are represented as eight groups of four hexadecimal digits, each group representing 16 bits. The groups are separated by colons (":"). For example, the address 2001:0db8:85a3:0000:0000:8a2e:0370:7334 is a valid one. Also, we could omit some leading zeros among four hexadecimal digits and some low-case characters in the address to upper-case ones, so 2001:db8:85a3:0:0:8A2E:0370:7334 is also a valid IPv6 address(Omit leading zeros and using upper cases).

        However, we don't replace a consecutive group of zero value with a single empty group using two consecutive colons (::) to pursue simplicity. For example, 2001:0db8:85a3::8A2E:0370:7334 is an invalid IPv6 address.

        Besides, extra leading zeros in the IPv6 is also invalid. For example, the address 02001:0db8:85a3:0000:0000:8a2e:0370:7334 is invalid.

        Note: You may assume there is no extra space or special characters in the input string.
     */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string ValidIPAddress(string IP)
        {
            var result = IsIPv4(IP);
            if (result != null)
            {
                foreach(var section in result)
                {
                    int value;
                    if (int.TryParse(section, out value))
                    {
                        if (value >= 0 && value <= 255)
                        {
                            if (value == 0 && section.Length > 1)
                            {
                                return "Neither";
                            }

                            return "IP4";
                        }
                    }
                    return "Neither";
                }
            }

            var result2 = IsIPv6(IP);
            if (result2 != null)
            {
                foreach(var section in result2)
                {
                    
                }
            }
            
            return "Neither";
        }

        private static bool IsHexNumber(char n)
        {
            // /[0-9a-fA-F]+/
            if (n >= 0 && n <= 15)
            {
                return true;
            }

            return false;
        }
        private static string[] IsIPv4(string IP)
        {
            var sections = IP.Split('.');
            if (sections.Length != 4)
            {
                return null;
            }
            return sections;
        }

        private static string[] IsIPv6(string IP)
        {
            var sections = IP.Split(':');
            if (sections.Length != 6)
            {
                return null;
            }
            return sections;
        }
    }
}