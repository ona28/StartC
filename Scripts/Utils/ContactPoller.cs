using UnityEngine;

namespace Platformer2D
{
    public class ContactPoller
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        
        private const float _collTreshold = 0.6f;
        private int _contactCount;
        private Collider2D _collider2D;

        public bool IsBottomContact { get; private set; }
        public bool IsTopContact { get; private set; }
        public bool IsLeftContact { get; private set; }
        public bool IsRightContact { get; private set; }


        public ContactPoller(Collider2D collider)
        {
            _collider2D = collider;
        }


        public void Update()
        {
            IsBottomContact = false;
            IsTopContact = false;
            IsLeftContact = false;
            IsRightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);

            for (int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _collTreshold) IsBottomContact = true;
                if (_contacts[i].normal.y > -_collTreshold) IsTopContact = true;
                if (_contacts[i].normal.x > -_collTreshold) IsRightContact = true;
                if (_contacts[i].normal.x > _collTreshold) IsLeftContact = true;
            }
        }
    }
}
