using System;

record RequestDTO(
    string type_goal,
    string name,
    string description,
    string points,
    int bonus,
    int target,
    int amount_completed,
    bool is_complete
)
{
    public static RequestDTO ToRequestDTO(Goal goal)
    {
        return new RequestDTO(
            goal.GetType().Name, 
            goal.GetName(), 
            goal.GetDescription(), 
            goal.GetPoints(), 
            goal.GetBonus(), 
            goal.GetTarget(), 
            goal.GetAmountCompleted(),
            goal.IsComplete()
        );
    }
}