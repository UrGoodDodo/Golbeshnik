using System;

public class OpenSettingsMenuTransition : IMenusTransitionRule
{
    public Type NextState => typeof(SettingsState); 

    public bool ShouldTransition(float deltaTime)
    {
        throw new NotImplementedException(); // ����� �� ������ �������� - true, � ��� ������� false;
    }
}
