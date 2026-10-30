# Max Number of K-Sum Pairs

## Problem Description

Given an integer array `nums` and an integer `k`.

In one operation, you can pick two numbers from the array whose sum equals `k` and remove them from the array.

Return the maximum number of operations you can perform on the array.

- **Problem Link:** [LeetCode - Max Number of K-Sum Pairs](https://leetcode.com/problems/max-number-of-k-sum-pairs/)
- **Proof of Submission:** [LeetCode - Max Number of K-Sum Pairs](https://leetcode.com/problems/max-number-of-k-sum-pairs/submissions/2156377324/)

## ![LeetCode Submission](image.png)

## Solution Overview (C#)

The solution uses a **Two-Pointer Approach** after sorting the array:

1. Sort the input array `nums` in non-decreasing order.
2. Initialize two pointers: `left` pointing at index `0` and `right` pointing at `nums.Length - 1`.
3. Loop while `left < right`:
   - If `nums[left] + nums[right] == k`, we found a valid pair. Increment operations counter `count`, and move both pointers inward (`left++`, `right--`).
   - If the sum is less than `k`, increment `left` to increase the total sum.
   - If the sum is greater than `k`, decrement `right` to decrease the total sum.

```csharp
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);
        int left = 0, right = nums.Length - 1, count = 0;

        while (left < right)
        {
            if (nums[left] + nums[right] == k)
            {
                count++;
                left++;
                right--;
            }
            else if (nums[left] + nums[right] < k)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return count;
    }
}
```
