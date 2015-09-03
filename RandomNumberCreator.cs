using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This RandomNumberCreator class uses the XOR shifting method to generate random float numbers
/// which can be altered depending on the initial seed. More information can be found at:
/// https://en.wikipedia.org/wiki/Xorshift
/// </summary>
/// <remarks> Fernando Cortez, 03/09/15. </remarks>
public class RandomNumberCreator {

    #region Private Variables
    /// <summary> The first of three consant uints which we must set manually. </summary>
    private const uint const1 = 1;
    /// <summary> The second of three consant uints which we must set manually. </summary>
    private const uint const2 = 2;
    /// <summary> The last of three consant uints which we must set manually. </summary>
    private const uint const3 = 3;
    
    /// <summary> The seed which will be modifiable externally. </summary>
    private static uint seed;
    /// <summary> First constant to be used in the random number calculation, set equal to the first const. </summary>
    private static uint constant1 = const1;
    /// <summary> Second constant to be used in the random number calculation, set equal to the second const. </summary>
    private static uint constant2 = const2;
    /// <summary> What the calulation returns, set to the third const. </summary>
    private static uint result = const3;
    #endregion 

    /// <summary>
    /// ResetConstants assigns the public constant values to the private const parameters.
    /// </summary>
    /// <remarks> This is done to always generate a random number dependent only on the set const numbers and the seed</remarks>
    private static void ResetConstants()
    {
        constant1 = const1;
        constant2 = const2;
        result = const3;
    }

    /// <summary>
    /// This method sets the seed to a new uint value. ResetConstants() is called here to initialize the constants.
    /// </summary>
    /// <param name="_seed"> A uint to serve as seed for random number calculation. </param>
    public static void SetSeed(uint _seed)
    {
        ResetConstants();
        seed = _seed;
    }

    /// <summary>
    /// InitRandomNumber() performs the XOR shifting calulation, using the intially set seed.
    /// </summary>
    /// <returns> Returns a float number. </returns>
    public static float InitRandomNumber()
    {
        uint t = (seed ^ (seed << 11));
        seed = constant1;
        constant1 = constant2;
        constant2 = result;
        result = (result ^ (result >> 19)) ^ (t ^ (t >> 8));
        
        return (float)result;
    }

    /// <summary>
    /// Performs random number generation and returns a random float number between _min and _max, both inclusive.
    /// </summary>
    /// <param name="_min"> Minumum float number. </param>
    /// <param name="_max"> Maximum float number. </param>
    /// <returns> Returns a whole value float number from _min to _max. </returns>
    /// <remarks> Requires that _min and _max be both greater than 0 and _max be greater than _min. </remarks>
    public static float RandomNumber(float _min, float _max)
    {
        return (InitRandomNumber() % (_max + 1 - _min)) + _min;
    }
}
