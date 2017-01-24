#region Copyright (C) 2014-2016 Sascha Simon

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

namespace Strava.Activities
{
    /// <summary>
    /// The type of an activity.
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// Riding.
        /// </summary>
        Ride,
        /// <summary>
        /// Running.
        /// </summary>
        Run,
        /// <summary>
        /// Swimming.
        /// </summary>
        Swim,
        /// <summary>
        /// Hiking.
        /// </summary>
        Hike,
        /// <summary>
        /// Walking.
        /// </summary>
        Walk,
        /// <summary>
        /// Apline Skiing.
        /// </summary>
        AlpineSki,
        /// <summary>
        /// Backcountry skiing.
        /// </summary>
        BackcountrySki,
        /// <summary>
        /// Canoeing.
        /// </summary>
        Canoeing,
        /// <summary>
        /// Cross country skiing.
        /// </summary>
        CrossCountrySkiing,
        /// <summary>
        /// Crossfit session.
        /// </summary>
        Crossfit,
        /// <summary>
        /// eBike ride.
        /// </summary>
        EBikeRide,
        /// <summary>
        /// Elliptical machine.
        /// </summary>
        Elliptical,
        /// <summary>
        /// Ice skating
        /// </summary>
        IceSkate,
        /// <summary>
        /// Inline skating.
        /// </summary>
        InlineSkate,
        /// <summary>
        /// Kayaking.
        /// </summary>
        Kayaking,
        /// <summary>
        /// Kitesurfing.
        /// </summary>
        Kitesurf,
        /// <summary>
        /// Nordic skiing.
        /// </summary>
        NordicSki,
        /// <summary>
        /// Rock climbing.
        /// </summary>
        RockClimbing,
        /// <summary>
        /// Roller skiing.
        /// </summary>
        RollerSki,
        /// <summary>
        /// Rowing.
        /// </summary>
        Rowing,
        /// <summary>
        /// Snowboarding.
        /// </summary>
        Snowboard,
        /// <summary>
        /// Snowshoeing.
        /// </summary>
        Snowshoe,
        /// <summary>
        /// Stair stepping machine.
        /// </summary>
        StairStepper,
        /// <summary>
        /// Stand up paddling.
        /// </summary>
        StandUpPaddling,
        /// <summary>
        /// Surfing.
        /// </summary>
        Surfing,
        /// <summary>
        /// Virtual ride.
        /// </summary>
        VirtualRide,
        /// <summary>
        /// Weight training.
        /// </summary>
        WeightTraining,
        /// <summary>
        /// Windsurfing.
        /// </summary>
        Windsurf,
        /// <summary>
        /// Workout.
        /// </summary>
        Workout,
        /// <summary>
        /// Yoga.
        /// </summary>
        Yoga
    }
}