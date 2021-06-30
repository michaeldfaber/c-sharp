public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int,int>();
        for(int i = 0; i < nums.Length; i++) {
            var element = nums[i];
            if (map.ContainsKey(element))
                return new int[]{map[element], i};
            var requiredElement = target-element;
            map[requiredElement]= i;
        }
        throw new ArgumentException("There must be atleast and exactly one solution");
    }
}