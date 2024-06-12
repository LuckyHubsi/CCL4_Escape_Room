/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_CAULDRON = 3212638512U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_MAGIC_BARRIER_DOOR = 2205790566U;
        static const AkUniqueID PLAY_MAGIC_BARRIER_WINDOW = 2862905942U;
        static const AkUniqueID PLAY_PLAYER_INTERACT = 305502530U;
        static const AkUniqueID PLAY_SMOKE = 2555336501U;
        static const AkUniqueID PLAY_TORCH_CRACKLING = 45744291U;
        static const AkUniqueID STOP_MAGIC_BARRIER_DOOR = 2992760128U;
        static const AkUniqueID STOP_MAGIC_BARRIER_WINDOW = 3780008132U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace IGNITION
        {
            static const AkUniqueID GROUP = 1572296608U;

            namespace STATE
            {
                static const AkUniqueID FALSE = 2452206122U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TRUE = 3053630529U;
            } // namespace STATE
        } // namespace IGNITION

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEPS
        {
            static const AkUniqueID GROUP = 2385628198U;

            namespace SWITCH
            {
                static const AkUniqueID GRASS = 4248645337U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS

        namespace PLAYERINTERACTSWITCH
        {
            static const AkUniqueID GROUP = 3391040932U;

            namespace SWITCH
            {
                static const AkUniqueID COMBINING_TORCH = 805831506U;
                static const AkUniqueID DEGNITION_TORCH = 1723853725U;
                static const AkUniqueID DROPPING_TORCH = 3013747789U;
                static const AkUniqueID EQUIPPING_TORCH = 1070326592U;
                static const AkUniqueID OTHER_TORCH_INTERACTION = 1918408915U;
                static const AkUniqueID WINDOW_RUNE_GONE = 1785219138U;
            } // namespace SWITCH
        } // namespace PLAYERINTERACTSWITCH

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID FOOTSTEPS = 2385628198U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MENU = 2607556080U;
        static const AkUniqueID PLAYER_INTERACT = 493210468U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
