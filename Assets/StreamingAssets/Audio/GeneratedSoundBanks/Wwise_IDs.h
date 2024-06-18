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
        static const AkUniqueID PLAY_BIRB = 1844467877U;
        static const AkUniqueID PLAY_BOOK_PAGE_TURN = 344332797U;
        static const AkUniqueID PLAY_CAT = 2690797150U;
        static const AkUniqueID PLAY_CAULDRON = 3212638512U;
        static const AkUniqueID PLAY_COUGHING = 1741894216U;
        static const AkUniqueID PLAY_DOOR_CLOSED = 828587345U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_MAGIC_BARRIER_DOOR = 2205790566U;
        static const AkUniqueID PLAY_MAGIC_BARRIER_WINDOW = 2862905942U;
        static const AkUniqueID PLAY_PLAYER_INTERACT = 305502530U;
        static const AkUniqueID PLAY_SMOKE = 2555336501U;
        static const AkUniqueID PLAY_SUCCESSFUL_COMBINATION = 4156768940U;
        static const AkUniqueID PLAY_TORCH_CRACKLING = 45744291U;
        static const AkUniqueID PLAY_WHITE_NOISE = 2214627026U;
        static const AkUniqueID PLAY_WRONG_COMBINATION = 3120915481U;
        static const AkUniqueID STOP_MAGIC_BARRIER_DOOR = 2992760128U;
        static const AkUniqueID STOP_MAGIC_BARRIER_WINDOW = 3780008132U;
        static const AkUniqueID STOP_PLAYER_INTERACT = 2314554776U;
        static const AkUniqueID STOP_SMOKE = 3366263883U;
        static const AkUniqueID STOP_TORCH_CRACKLING = 642243045U;
        static const AkUniqueID STOP_WHITE_NOISE = 3995502072U;
    } // namespace EVENTS

    namespace SWITCHES
    {
        namespace COUGHING
        {
            static const AkUniqueID GROUP = 2427782015U;

            namespace SWITCH
            {
                static const AkUniqueID HEAVY = 2732489590U;
                static const AkUniqueID LIGHT = 1935470627U;
                static const AkUniqueID MEDIUM = 2849147824U;
            } // namespace SWITCH
        } // namespace COUGHING

        namespace FOOTSTEPS
        {
            static const AkUniqueID GROUP = 2385628198U;

            namespace SWITCH
            {
                static const AkUniqueID GRASS = 4248645337U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS

        namespace MAGICBARRIERWINDOW
        {
            static const AkUniqueID GROUP = 510690747U;

            namespace SWITCH
            {
                static const AkUniqueID ACTIVE = 58138747U;
                static const AkUniqueID INACTIVE = 3163453698U;
            } // namespace SWITCH
        } // namespace MAGICBARRIERWINDOW

        namespace PLAYERINTERACTSWITCH
        {
            static const AkUniqueID GROUP = 3391040932U;

            namespace SWITCH
            {
                static const AkUniqueID COMBINING_TORCH = 805831506U;
                static const AkUniqueID DEGNITION_TORCH = 1723853725U;
                static const AkUniqueID DROP_BUCKET = 3643606539U;
                static const AkUniqueID DROP_KEY = 1807111158U;
                static const AkUniqueID DROPPING_POTION = 838125300U;
                static const AkUniqueID DROPPING_TORCH = 3013747789U;
                static const AkUniqueID EQUIP_BUCKET = 3166695468U;
                static const AkUniqueID EQUIPPING_KEY = 3147764383U;
                static const AkUniqueID EQUIPPING_POTION = 2633107091U;
                static const AkUniqueID EQUIPPING_TORCH = 1070326592U;
                static const AkUniqueID EQUIPPING_WATERBUCKET = 3481100345U;
                static const AkUniqueID OTHER_TORCH_INTERACTION = 1918408915U;
                static const AkUniqueID USE_KEY = 3782926630U;
                static const AkUniqueID USING_POTION = 4110363151U;
                static const AkUniqueID USING_WATER = 3048428183U;
            } // namespace SWITCH
        } // namespace PLAYERINTERACTSWITCH

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID SMOKE_INTENSITY = 46447142U;
    } // namespace GAME_PARAMETERS

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
