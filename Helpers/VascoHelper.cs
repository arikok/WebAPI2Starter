using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasco;

namespace WepAPI2Starter.Helpers
{
    public static class VascoHelper
    {
        private const byte ChallangeLength = 8;
        private const byte ResponseLength = 8;
        private const byte UnlockChallangeLength = 7;
        private const byte UnlockResponseLength = 8;

        //SPManagedGetChallange
        public static int ManagedGetChallange(ref String dpData, out string challange, out string logMessage)
        {
            int result = 0;

            challange = string.Empty;
            logMessage = string.Empty;


            try
            {
                AAL2Wrap aal2Wrapper = new AAL2Wrap();
                challange = aal2Wrapper.AAL2GenerateChallenge(ref dpData);

            }
            catch (Exception exception)
            {
                logMessage = exception.Message;
            }

            return result;
        }

        //SPManagedCheckResponse
        public static int CheckResponse(ref String dpData, string challange, string response, out bool responseConfirmed, out string logMessage)
        {
            int result = 0;

            responseConfirmed = false;

            logMessage = string.Empty;

            try
            {
                AAL2Wrap wrapper = new AAL2Wrap();

                result = wrapper.AAL2VerifyPassword(ref dpData, challange, response);
                responseConfirmed = result == 0;

            }
            catch (Exception exception)
            {
                logMessage = exception.Message;
            }
            return result;
        }

        //SPManagedUnlockDigipass
        public static void UnlockDigipass(ref String dpData, int randomNumber, out int unlockResponse, out string logMessage)
        {
            AAL2Wrap wrapper = new AAL2Wrap();

            unlockResponse = 0;
            logMessage = string.Empty;
            string _unlockResponse = string.Empty;

            try
            {
                string bRandomNumber = padWithZero(randomNumber, UnlockChallangeLength);
                _unlockResponse = wrapper.AAL2Unlock(ref dpData, bRandomNumber);
                int.TryParse(_unlockResponse, out unlockResponse);
            }
            catch (Exception exception)
            {
                logMessage = exception.Message;
            }
        }



        private static string padWithZero(int number, byte length)
        {
            return padWithZero(number.ToString(), length);
        }

        private static string padWithZero(string number, byte length)
        {
            return number.PadLeft(length, '0');
        }


    }
}