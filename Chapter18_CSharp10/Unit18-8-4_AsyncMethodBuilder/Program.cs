

using System.Runtime.CompilerServices;

[AsyncMethodBuilder(typeof(AsyncValueTaskMethodBuilder))]
public readonly struct ValueTask : IEquatable<ValueTask>
{

}

// 개선 후
// 사용자 정의 Task 타입을 경유하지 ㅇ낳고 
// 메서드의 특성에 지정해 사용
[AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder<>))]
public static async ValueTask<int> GetSalaryAsync()
{
    await Task.Delay(0);
    return 60;
}


