import { nextFieldKey } from './form.utils';

describe('nextFieldKey', () => {
  it('starts at field1', () => {
    expect(nextFieldKey([])).toBe('field1');
  });

  it('skips existing keys', () => {
    expect(nextFieldKey(['field1', 'field2'])).toBe('field3');
  });
});
