#!/bin/sh

gpg --quiet --batch --yes --decrypt --passphrase="$SECRETS_PASSPHRASE" --output=sa.key sa.key.gpg
