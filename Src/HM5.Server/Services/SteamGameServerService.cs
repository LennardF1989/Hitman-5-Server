using System.Runtime.InteropServices;
using System.Text;
using HM5.Server.Interfaces;

namespace HM5.Server.Services
{
    public class SteamGameServerService : ISteamService
    {
        private const string LibraryName = "steam_api64";
        private const CallingConvention CC = CallingConvention.Cdecl;

        [DllImport(LibraryName, EntryPoint = "SteamInternal_GameServer_Init", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool SteamInternal_GameServer_Init(uint unIP, ushort usPort, ushort usGamePort, ushort usQueryPort, int eServerMode, IntPtr pchVersionString);

        [DllImport(LibraryName, EntryPoint = "SteamAPI_SteamGameServer_v015", CallingConvention = CC)]
        private static extern IntPtr SteamAPI_SteamGameServer_v015();

        [DllImport(LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_BeginAuthSession", CallingConvention = CC)]
        private static extern int SteamAPI_ISteamGameServer_BeginAuthSession(IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, ulong steamId);

        [DllImport(LibraryName, EntryPoint = "SteamAPI_ISteamGameServer_EndAuthSession", CallingConvention = CC)]
        private static extern void SteamAPI_ISteamGameServer_EndAuthSession(IntPtr self, ulong steamId);

        private readonly IntPtr _instance;

        public SteamGameServerService()
        {
            const string appId = "203140";

            Environment.SetEnvironmentVariable("SteamAppId", appId);
            Environment.SetEnvironmentVariable("SteamGameId", appId);

            var versionBytes = Encoding.UTF8.GetBytes("1.0.0.0");
            var hVersionBytes = GCHandle.Alloc(versionBytes, GCHandleType.Pinned);
            var pVersionBytes = hVersionBytes.AddrOfPinnedObject();

            var result = SteamInternal_GameServer_Init(0x7f000001, 0, 0, 0, 1, pVersionBytes);

            hVersionBytes.Free();

            if (!result)
            {
                return;
            }

            _instance = SteamAPI_SteamGameServer_v015();
        }

        public Task<bool> AuthenticateUser(byte[] authTicketDataBytes, ulong steamId)
        {
            var hAuthTicket = GCHandle.Alloc(authTicketDataBytes, GCHandleType.Pinned);
            var pAuthTicket = hAuthTicket.AddrOfPinnedObject();

            var result = SteamAPI_ISteamGameServer_BeginAuthSession(_instance, pAuthTicket, authTicketDataBytes.Length, steamId);
            SteamAPI_ISteamGameServer_EndAuthSession(_instance, steamId);

            hAuthTicket.Free();

            return Task.FromResult(result == 0);
        }
    }
}