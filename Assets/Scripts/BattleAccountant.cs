using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;



public class BattleAccountant: MonoBehaviour
{
    public static UnityEvent<Actor> GetKindHitEvent = new UnityEvent<Actor>();

    private ITurnState _turnState;

    private List<Actor> _listSwords = new List<Actor>();

    [SerializeField]
    private float _targetTime;

    

    private void ClearListSword()
    {
        _listSwords.Clear();
    }
    private void GetSwordBehavior(Actor actor)
    {
        AddSwordInList(actor);
    }

    private void AddSwordInList(Actor actor)
    {
        _listSwords.Add(actor);
    }

    private void RandomSwordState()
    {
        int num = Random.Range(0, 2);

        _turnState = num == 0 ? new AttackState() : new DefState();

    }

    private void ComparerSwordState()
    {
        var player = _listSwords[1].gameObject.GetComponent<Player>();
        var enemy = _listSwords[0].gameObject.GetComponent<Enemy>();

        _turnState.ÑalculateTurn(player, enemy);

        SwitchSwordState();
    }

    private void SwitchSwordState()
    {
        if (_turnState.GetType() == typeof(DefState))
        {
            _turnState = new AttackState();
        }
        else
        {
            _turnState = new DefState();
        }
    }

    private async void Timer()
    {
        var time = 0f;

        while(time < 3f)
        {
            time += Time.deltaTime/3;
            Debug.Log(time);
        }

        await Task.Yield();
    }

    private void Output()
    {
        
        foreach (var value in _listSwords)
        {
            Debug.Log(value.name);
        }
    }

    private void OnEnable()
    {
        ClearListSword();
        
        GetKindHitEvent.AddListener(GetSwordBehavior);
        
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        RandomSwordState();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ITimer(_targetTime));
            Output();
            ComparerSwordState();
        }
    }

    private void OnDisable()
    {
        GetKindHitEvent.RemoveListener(GetSwordBehavior);
    }

    IEnumerator ITimer(float sec)
    {
        yield return new WaitForSeconds(sec);

        for (int i = 0; i < _listSwords.Count; i++)
        {
            _listSwords[i].GetComponent<Player>().MoveSwordOnTargetPositionEvent.Invoke();
        }

    }
}
