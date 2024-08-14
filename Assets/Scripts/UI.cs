using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _coinText;
    [SerializeField] private ParticleSystem _particleSystem;
    private void Start()
    {
        GetScreenSize gets = new GetScreenSize();
        Debug.Log(gets.ScreenSize());
        Player.OnNewCoin += NewCoin;
    }
    private void NewCoin()
    {
        _coinText.text = _player.GetCoin().ToString();
    }
    public void UIVFX(InputAction.CallbackContext context)
    {
        if(context.performed)
            _particleSystem.Play();
    }
}
